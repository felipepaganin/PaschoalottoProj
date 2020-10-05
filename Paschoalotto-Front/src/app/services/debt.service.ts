import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, observable } from 'rxjs';
import { IDebt } from '../Utils/interfaces';

@Injectable({
  providedIn: 'root'
})

export class DebtService {
  readonly base_url = "https://localhost:5001"
  constructor(private httpClient: HttpClient) { }

  public getDebts(): Observable<IDebt> {
    return this.httpClient.get<IDebt>(`${this.base_url}/api/debt`);
  }

  public addDebt(debt: IDebt): Observable<IDebt> {
    return this.httpClient.post<IDebt>(`${this.base_url}/api/debt/add-debt`,debt);
  }
}