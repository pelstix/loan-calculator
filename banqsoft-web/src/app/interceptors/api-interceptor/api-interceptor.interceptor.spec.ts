import { TestBed } from '@angular/core/testing';
import {
    HttpClientTestingModule,
    HttpTestingController,
} from '@angular/common/http/testing';
import { HttpClient, HttpRequest, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ApiInterceptor } from './api-interceptor.interceptor';
import { LoanService } from 'src/app/services/loan/loan.service';
import { environment } from 'src/environments/environment';

describe(`ApiInterceptor`, () => {
    beforeEach(() => {
        TestBed.configureTestingModule({
            imports: [HttpClientTestingModule],
            providers: [
                LoanService,
                {
                    provide: HTTP_INTERCEPTORS,
                    useClass: ApiInterceptor,
                    multi: true,
                },
            ],
        });
    });

    it('should append api url before path', () => {

        const httpClient = TestBed.inject(HttpClient);
        const httpTestingController = TestBed.inject(HttpTestingController);

        httpClient.get('test')
            .subscribe(data =>
                expect(data).toBeTruthy()
            );

        const request = httpTestingController.expectOne((req: HttpRequest<any>) => {
            return req.url.includes(environment.apiUrl)
                && req.url.includes('test');
        });

        expect(request.request.method).toEqual('GET');

        httpTestingController.verify();
    });
});
