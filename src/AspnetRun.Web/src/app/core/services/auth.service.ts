import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import * as moment from "moment";
import { environment } from 'src/environments/environment';
import { tap } from 'rxjs/operators';

@Injectable()
export class AuthService {

    constructor(private httpClient: HttpClient) { }

    login(email: string, password: string) {
        var request = { email: email, password: password };

        return this.httpClient.post<boolean>(environment.apiUrl + '/Account/CreateToken', request)
            .pipe(tap(this.setSession));
    }

    private setSession(authResult: any) {
        const authExpiration = moment(authResult.expiration);

        localStorage.setItem('authToken', authResult.token);
        localStorage.setItem("authExpiration", JSON.stringify(authExpiration.valueOf()));
    }

    logout() {
        localStorage.removeItem("authToken");
        localStorage.removeItem("authExpiration");
    }

    public isLoggedIn() {
        return moment().isBefore(this.getExpiration());
    }

    isLoggedOut() {
        return !this.isLoggedIn();
    }

    getExpiration() {
        const expiration = localStorage.getItem("authExpiration");
        const expiresAt = JSON.parse(expiration);
        return moment(expiresAt);
    }
}
