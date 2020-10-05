import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { DebtService } from 'src/app/services/debt.service';

@Component({
  selector: 'app-debt',
  templateUrl: './debt.component.html',
  styleUrls: ['./debt.component.scss']
})
export class DebtComponent implements OnInit {

  debtForm = this.fb.group({
    titleNumber: ['', Validators.pattern('^[0-9]*$')],
    name: [''],
    cpf: [''],
    finefee: [''],
    interest: [''],
    parcel: [''],
    parcelnumber: [''],
    dueDate: [''],
    price: [''],
  });

  constructor(
    private fb: FormBuilder,
    private _service: DebtService,
    private _toastrService: ToastrService) { }

  ngOnInit(): void {
  }

  public async save() {

    await this._service.addDebt(this.debtForm.value).subscribe(res => {
      this._toastrService.success(`Registro inserido com suceeso`)
      console.log(res);
    });
  }
}