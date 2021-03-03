import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { MatSliderModule } from '@angular/material/slider';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoanCalculatorComponent } from './loan-calculator/loan-calculator.component';
import { ApiInterceptor } from './interceptors/api-interceptor/api-interceptor.interceptor';
import { YearMonthGridPipe } from './pipes/year-month-grid/year-month-grid.pipe';

@NgModule({
    declarations: [
        AppComponent,
        LoanCalculatorComponent,
        YearMonthGridPipe
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        NoopAnimationsModule,
        ReactiveFormsModule,
        HttpClientModule,

        MatSliderModule,
        MatInputModule,
        MatSelectModule,
    ],
    providers: [
        {
            provide: HTTP_INTERCEPTORS,
            useClass: ApiInterceptor,
            multi: true,
        },
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
