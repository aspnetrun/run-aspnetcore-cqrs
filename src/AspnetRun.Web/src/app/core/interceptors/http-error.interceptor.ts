import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpErrorResponse } from '@angular/common/http';
import { Observable, empty } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

export class HttpErrorInterceptor implements HttpInterceptor {
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request)
            .pipe(
                catchError((error: HttpErrorResponse) => {
                    let errorMessage = '';

                    if (error.error instanceof ErrorEvent) {
                        // client-side error
                        errorMessage = `Error: ${error.error.message}`;
                    }
                    else {
                        // server-side error
                        errorMessage = `Error Code: ${error.status} | Message: ${error.message}`;
                    }

                    if (!environment.production) {
                        console.log(error);
                    }

                    //TODO: a popup will be shown
                    console.log(errorMessage);

                    return empty();
                })
            )
    }
}