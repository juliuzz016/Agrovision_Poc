import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-agents',
  templateUrl: './agents.component.html',
  styleUrls: ['./agents.component.sass']
})
export class AgentsComponent implements OnInit {

  
  SprayingAgentForm: FormGroup;
  constructor(private fb: FormBuilder) { 
    this.SprayingAgentForm = this.fb.group({
      SprayingAgentName: [null, Validators.required],
      SprayingAgentQty: [null, Validators.min(0)]
     });

  }

  ngOnInit(): void {
  }

}
