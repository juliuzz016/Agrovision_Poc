import { Component, OnInit } from '@angular/core';
import { SprayModel } from 'src/app/models/spray/spray.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Spray_CalculatorHttpService } from 'src/app/services/http.spray_calculator.services';

@Component({
  selector: 'app-sprayers',
  templateUrl: './sprayers.component.html',
  styleUrls: ['./sprayers.component.sass']
})
export class SprayersComponent implements OnInit {
  sprays: SprayModel[] = [];
  SprayingForm: FormGroup;
  constructor(private fb: FormBuilder, private _spray_CalculatorHttpService: Spray_CalculatorHttpService) {
    this.SprayingForm = this.fb.group({
      Description: [null, Validators.required],
      SparyerVolumeL: [null, Validators.min(0)]
     });
   }

  ngOnInit(): void {
    this.GetActiveSpray();
  }
  
  onSubmit() {
    const newField = new SprayModel(this.SprayingForm.value.Description , this.SprayingForm.value.SparyerVolumeL);
    this._spray_CalculatorHttpService.CreateSpraying(newField).subscribe(z => {
      this.GetActiveSpray();
      this.SprayingForm.reset();
    })
  }
  GetActiveSpray() {
    this._spray_CalculatorHttpService.GetActiveSpraying().subscribe(res => {
      this.sprays = res
    }, error => {

    });
  }

}
