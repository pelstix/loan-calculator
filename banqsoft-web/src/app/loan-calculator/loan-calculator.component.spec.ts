import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatSliderModule } from '@angular/material/slider';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';

import { LoanCalculatorComponent } from './loan-calculator.component';

describe('LoanCalculatorComponent', () => {
    let component: LoanCalculatorComponent;
    let fixture: ComponentFixture<LoanCalculatorComponent>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            declarations: [LoanCalculatorComponent],
            imports: [
                HttpClientTestingModule,
                MatSliderModule,
                MatInputModule,
                MatSelectModule,
                NoopAnimationsModule,
                MatFormFieldModule,
            ],
        })
            .compileComponents();
    });

    beforeEach(() => {
        fixture = TestBed.createComponent(LoanCalculatorComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
