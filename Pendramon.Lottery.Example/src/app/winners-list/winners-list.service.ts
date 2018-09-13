import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { IUserCodeAward } from "src/app/winners-list/winners-list.model";
import { Observable } from "rxjs/internal/Observable";

@Injectable({
    providedIn: 'root'
})
export class WinnersListService {
    winnersUrl: string = "http://localhost:52843/api/lottery/";
    constructor(private http: HttpClient) { 
        
    }

    public getAllWinners() : Observable<Array<IUserCodeAward>> {
        return this.http.get<Array<IUserCodeAward>>(this.winnersUrl + "getAllWinners");
    }
}