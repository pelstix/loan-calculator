import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoanExtract } from 'src/app/models/loan-extract';
import { LoanPayment } from 'src/app/models/loan-payment';

@Injectable({
    providedIn: 'root'
})
export class LoanService {

    private readonly servicePath = 'loan';

    constructor(
        private httpClient: HttpClient,
    ) { }

    public GetAvailableLoans(): Observable<Array<LoanExtract>> {

        return this.httpClient.get<Array<LoanExtract>>(`${this.servicePath}`);
    }

    public CalculateLoan(loanId: number, loanAmount: number, loanYearsDuration: number): Observable<Array<LoanPayment>> {

        return this.httpClient.post<Array<LoanPayment>>(`${this.servicePath}/calculate`, {
            loanId,
            loanAmount,
            loanYearsDuration,
        });
    }

}
