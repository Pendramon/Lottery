import { Observable } from "rxjs/internal/Observable";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { IUserCode, IAward } from "../winners-list/winners-list.model";

@Injectable({
    providedIn: 'root'
})
export class SubmitCodeService {
    lotteryUrl: string = "http://localhost:52843/api/lottery/";
    constructor(private http: HttpClient){

    }

    submitCode(userCode: IUserCode) : Observable<IAward> {
        return this.http.post<IAward>(this.lotteryUrl + 'submitCode', userCode);
    }
}