import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpInterceptor } from '@angular/common/http';
import { FieldModel } from '../models/field/field.model';
import { Observable } from 'rxjs';
import { retry, catchError, take, mapTo, map } from 'rxjs/operators';
import { AgentModel } from '../models/agent/agent.model';
import { SprayModel } from '../models/spray/spray.model';
import { calculationRequestModel } from '../models/calculator/calculationModel';
import { DosageCalculationResponse } from '../models/calculator/DosageCalculationResponse.Model';

@Injectable()
export class Spray_CalculatorHttpService {
    baseurl: string;
    constructor(private http: HttpClient) {
        this.baseurl = 'http://localhost:65315/api/'
    }
    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    };
    CalculateDosage(data: calculationRequestModel): Observable<DosageCalculationResponse> {
        return this.http.post<DosageCalculationResponse>(this.baseurl + 'DosageCalculator/CalculateDosage',
            JSON.stringify(data), this.httpOptions)
            .pipe(
                retry(1),
                take(1),
                catchError(error => {
                    throw (error);
                })
            );
    }
    CreateField(data: FieldModel): Observable<FieldModel> {
        return this.http.post<FieldModel>(this.baseurl + 'Field/CreateField',
            JSON.stringify(data), this.httpOptions)
            .pipe(
                retry(1),
                take(1),
                catchError(error => {
                    throw (error);
                })
            );
    }
    GetActiveFields(): Observable<FieldModel[]> {
        return this.http.get<FieldModel[]>(this.baseurl + 'Field/GetActiveFields', this.httpOptions)
            .pipe(
                retry(1),
                take(1),
                catchError(error => {
                    throw (error);
                })
            );
    }
   CreateSprayingAgent(data: AgentModel): Observable<AgentModel> {
        return this.http.post<AgentModel>(this.baseurl + 'SprayingAgent/CreateSprayingAgent',
            JSON.stringify(data), this.httpOptions)
            .pipe(
                retry(1),
                take(1),
                catchError(error => {
                    throw (error);
                })
            );
    }
    GetActiveSprayingAgent(): Observable<AgentModel[]> {
        return this.http.get<AgentModel[]>(this.baseurl + 'SprayingAgent/GetActiveSprayingAgent', this.httpOptions)
            .pipe(
                retry(1),
                take(1),
                catchError(error => {
                    throw (error);
                })
            );
    }
    CreateSpraying(data: SprayModel): Observable<SprayModel> {
        return this.http.post<SprayModel>(this.baseurl + 'Sprays/CreateSpray',
            JSON.stringify(data), this.httpOptions)
            .pipe(
                retry(1),
                take(1),
                catchError(error => {
                    throw (error);
                })
            );
    }
    GetActiveSpraying(): Observable<SprayModel[]> {
        return this.http.get<SprayModel[]>(this.baseurl + 'Sprays/GetActiveSprays', this.httpOptions)
            .pipe(
                retry(1),
                take(1),
                catchError(error => {
                    throw (error);
                })
            );
    }

}