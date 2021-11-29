//import '.src/polyfills';
//import { MbscModule } from '@mobiscroll/angular-lite';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent, AddProjectDialog, AddNotesDialog, AddLocationsDialog, DraggableDialogDirective } from './app.component';
import { HttpClientModule } from  '@angular/common/http';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../environments/environment';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { AppMaterialModules } from './material.module';
import { HttpModule } from '@angular/http';



@NgModule({
  declarations: [
    AppComponent,AddProjectDialog,AddNotesDialog, AddLocationsDialog, DraggableDialogDirective
  ],
  imports: [ 
    
   // MATERIAL_COMPATIBILITY_MODE,
    BrowserModule,
    HttpClientModule,
    NoopAnimationsModule,
	  FormsModule,
	  ReactiveFormsModule,

    HttpModule,
	// Material Modules
    AppMaterialModules,

	ServiceWorkerModule.register('ngsw-worker.js', { enabled: environment.production })
  ],
  entryComponents: [AppComponent, AddProjectDialog, AddNotesDialog, AddLocationsDialog],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
