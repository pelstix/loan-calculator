import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { of, ReplaySubject } from 'rxjs';
import { catchError, concatMap, filter, startWith, takeUntil, tap } from 'rxjs/operators';
import { LoanExtract } from '../models/loan-extract';
import { LoanPayment } from '../models/loan-payment';
import { LoanService } from '../services/loan/loan.service';

@Component({
    selector: 'app-loan-calculator',
    templateUrl: './loan-calculator.component.html',
    styleUrls: ['./loan-calculator.component.scss']
})
export class LoanCalculatorComponent implements OnInit, OnDestroy {

    public readonly loanAmountMin = 10000;
    public readonly loanAmountMax = 5000000;
    public readonly loanAmountStep = 10000;
    public readonly loanYearsDurationMin = 1;
    public readonly loanYearsDurationMax = 40;
    public readonly loanYearsDurationStep = 1;

    public formGroup = new FormGroup({
        loanId: new FormControl(null, [Validators.required]),
        loanAmount: new FormControl(100000, [Validators.required, Validators.min(this.loanAmountMin), Validators.max(this.loanAmountMax)]),
        loanYearsDuration: new FormControl(10, [
            Validators.required,
            Validators.min(this.loanYearsDurationMin),
            Validators.max(this.loanYearsDurationMax)
        ]),
    });
    public loanPayments: Array<LoanPayment>;
    public loanExtracts: Array<LoanExtract>;
    public labelNames = [
        'January', 'February', 'March', 'April', 'May', 'June', 'July',
        'August', 'September', 'October', 'November', 'December', 'Total',
    ];
    public errorOccurred = false;
    public isLoading = true;

    private destroyed$: ReplaySubject<boolean> = new ReplaySubject(1);

    constructor(
        private loanService: LoanService,
    ) { }

    public ngOnInit(): void {
        this.loadAvailableLoans();
        this.watchForFormChanges();
    }

    public ngOnDestroy(): void {
        this.destroyed$.next(true);
        this.destroyed$.complete();
    }

    public formatAmount(value: number): string {

        if (value > 1000000) {
            return Math.round(value / 100000) / 10 + 'M';
        }

        return Math.round(value / 1000) + 'k';
    }

    private loadAvailableLoans(): void {

        this.loanService.GetAvailableLoans().subscribe(loanExtracts => {
            this.loanExtracts = loanExtracts;
        });
    }

    private watchForFormChanges(): void {

        this.formGroup.valueChanges.pipe(
            startWith({
                loanId: this.formGroup.get('loanId').value,
                loanAmount: this.formGroup.get('loanAmount').value,
                loanYearsDuration: this.formGroup.get('loanYearsDuration').value,
            }),
            takeUntil(this.destroyed$),
            filter(_ => this.formGroup.valid),
            tap(_ => {
                this.errorOccurred = false;
                this.isLoading = true;
            }),
            concatMap(formValue =>
                this.loanService.CalculateLoan(
                    formValue.loanId,
                    formValue.loanAmount,
                    formValue.loanYearsDuration,
                ).pipe(
                    catchError(_ => {
                        this.errorOccurred = true;
                        return of(null);
                    })
                )
            ),
        ).subscribe(
            loanPayments => {
                this.isLoading = false;
                this.loanPayments = loanPayments;
            }
        );
    }
}
