import { Observable } from "rxjs/internal/Observable";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { IUserCode, IAward } from "../winners-list/winners-list.model";
import { environment } from "src/environments/environment";

@Injectable({
    providedIn: 'root'
})
export class SubmitCodeService {
    constructor(private http: HttpClient){

    }

    submitCode(userCode: IUserCode) : Observable<IAward> {
        return this.http.post<IAward>(environment + 'submitCode', userCode);
    }
}