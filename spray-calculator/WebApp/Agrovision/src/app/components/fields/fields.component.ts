import { Component, OnInit } from '@angular/core';
import { Spray_CalculatorHttpService } from 'src/app/services/http.spray_calculator.services';
import { FieldModel } from 'src/app/models/field/field.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-fields',
  templateUrl: './fields.component.html',
  styleUrls: ['./fields.component.sass']
})
export class FieldsComponent implements OnInit {

  fields: FieldModel[] = [];
  fieldsForm: FormGroup;
  constructor(private _spray_CalculatorHttpService: Spray_CalculatorHttpService, private fb: FormBuilder) {

    this.fieldsForm = this.fb.group({
      Description: [null, Validators.required],
      FieldSize: [null, Validators.required]
    });
  }
  onFieldSubmit() {
    const newField = new FieldModel(this.fieldsForm.value.Description , this.fieldsForm.value.FieldSize);
    this._spray_CalculatorHttpService.CreateField(newField).subscribe(z => {
      this.GetActiveFields();
      this.fieldsForm.reset();
    })
  }
  ngOnInit(): void {
    this.GetActiveFields();
  }
  GetActiveFields() {
    this._spray_CalculatorHttpService.GetActiveFields().subscribe(res => {
      this.fields = res
    }, error => {

    });
  }

}
