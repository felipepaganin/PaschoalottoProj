import { TestBed } from '@angular/core/testing'

// this period is for test.. need to change or remove 
export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
  description: string;
  parcel: string
}

export interface IDebt {
  Number: number;
  Name: string;
  CPF: string;
  Interest: number;
  FineFee: number;
  DebtInstallment: IDebtInstallment;
}

export interface IDebtInstallment {
  Number: number;
  DueDate: Date;
  Price: number;
}