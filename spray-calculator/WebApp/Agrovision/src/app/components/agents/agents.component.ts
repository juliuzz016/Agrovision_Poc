import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AgentModel } from 'src/app/models/agent/agent.model';
import { Spray_CalculatorHttpService } from 'src/app/services/http.spray_calculator.services';

@Component({
  selector: 'app-agents',
  templateUrl: './agents.component.html',
  styleUrls: ['./agents.component.sass']
})
export class AgentsComponent implements OnInit {

  agents: AgentModel[] = [];
  SprayingAgentForm: FormGroup;
  constructor(private fb: FormBuilder, private _spray_CalculatorHttpService: Spray_CalculatorHttpService) { 
    this.SprayingAgentForm = this.fb.group({
      SprayingAgentName: [null, Validators.required],
      recomendedDosage: [null, Validators.min(0)]
     });

  }

  ngOnInit(): void {
    this.GetActiveAgents();
  }
  
  onSubmit() {
    const newField = new AgentModel(this.SprayingAgentForm.value.SprayingAgentName , this.SprayingAgentForm.value.recomendedDosage);
    this._spray_CalculatorHttpService.CreateSprayingAgent(newField).subscribe(z => {
      this.GetActiveAgents();
      this.SprayingAgentForm.reset();
    })
  }
  GetActiveAgents() {
    this._spray_CalculatorHttpService.GetActiveSprayingAgent().subscribe(res => {
      this.agents = res
    }, error => {

    });
  }

}
