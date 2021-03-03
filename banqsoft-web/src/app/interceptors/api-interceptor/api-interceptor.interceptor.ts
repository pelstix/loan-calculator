import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable()
export class ApiInterceptor implements HttpInterceptor {

    public intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        const apiUrl = environment.apiUrl;
        const apiReq = req.clone({ url: `${apiUrl}/${req.url}` });
        return next.handle(apiReq);
    }
}
