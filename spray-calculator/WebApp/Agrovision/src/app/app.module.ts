import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule } from './app-routing/app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatDividerModule } from '@angular/material/divider';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatExpansionModule } from '@angular/material/expansion';
import {MatFormFieldModule} from '@angular/material/form-field';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AgentsComponent } from './components/agents/agents.component';
import { FieldsComponent } from './components/fields/fields.component';
import { SprayersComponent } from './components/sprayers/sprayers.component';
import { CalculatorComponent } from './components/calculator/calculator.component';
import {MatTabsModule} from '@angular/material/tabs';

@NgModule({
  declarations: [
    AppComponent,
    AgentsComponent,
    FieldsComponent,
    SprayersComponent,
    CalculatorComponent
  ],
  imports: [
    NgbModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatDividerModule,
    MatInputModule,
    MatCardModule,
    MatExpansionModule,
    MatFormFieldModule,
    FormsModule, 
    ReactiveFormsModule,
    MatTabsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
