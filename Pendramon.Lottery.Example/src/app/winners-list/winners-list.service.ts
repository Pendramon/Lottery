import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { IUserCodeAward } from "src/app/winners-list/winners-list.model";
import { Observable } from "rxjs/internal/Observable";
import { environment } from "src/environments/environment";

@Injectable({
    providedIn: 'root'
})
export class WinnersListService {
    constructor(private http: HttpClient) { 
        
    }

    public getAllWinners() : Observable<Array<IUserCodeAward>> {
        return this.http.get<Array<IUserCodeAward>>(environment.webApiUrl + "getAllWinners");
    }
}