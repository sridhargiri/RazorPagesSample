import {DataSource} from '@angular/cdk/collections';
import {Observable} from 'rxjs-compat/Observable';
import {FormControl, FormGroupDirective, NgForm, Validators, FormBuilder, FormsModule} from '@angular/forms';
import 'rxjs-compat/add/observable/of';
//import { of } from 'rxjs/Observable/of';
import { ChangeDetectorRef, Directive, ElementRef, Input, NgZone, OnDestroy,Component, OnInit, Inject } from  '@angular/core';
import { fromEvent, Subject, of as observableOf } from 'rxjs';
import { map, switchMap, takeUntil } from 'rxjs/operators';
import ResizeObserver from 'resize-observer-polyfill';
import { ApiService } from  './api.service';
import { Item } from  './api.service';
import {delay} from 'rxjs/operators';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';


  



@Component({
selector:  'app-root',
templateUrl:  './app.component.html',
styleUrls: ['./app.component.css']
})

export  class  AppComponent  implements  OnInit{

color = 'primary';
mode = 'Indeterminate';
isLoading = true;
errorText ='';
title  =  'pwademo';
gender;
weekList:any[] = [];
//weekList = ['01-Sep-2018 to 07-Sep-2018', '27-Oct-2018 to 02-Nov-2018'];
items:  Array<Item>;
//demo: Array < Date > = fromMonday;
isSelected;
selectedValue;
weekDays:any[] = [];
//weekDates:any[] = [];
dateValues;
weekEntries:any[] = [];
weekHours:any[] = [];
weekEntriesUpdated:any[] = [];
projects:any[] = [];
edit = true;
//selectedProject = "";
subProjects:[] = [];
dayOneTotalHours:number  = 0;
dayTwoTotalHours:number  = 0;
dayThreeTotalHours:number  = 0;
dayFourTotalHours:number  = 0;
dayFiveTotalHours:number = 0;
daySixTotalHours:number = 0;
daySevenTotalHours:number = 0;

dayTotalHours:number = 0;
disableButton: boolean = true;
hoursError: boolean = false;
selectedCheckBoxes = [];
selectedCheckBoxesData = [];
copied: boolean = true;
checkedBox =[];
jsonData:any[] = [];
userData;
addNotesData:any[] = [];
dialogueProjects:any[] = [];
dialogueNotes:any[] = [];
dialogueLocations:any[] = [];
//const progressBar: number = 0;
eventDate;
duplicateRows = [];
constructor(private  apiService:  ApiService, public dialog: MatDialog){
}

openDialogToAddProject(): void {
this.dialogueProjects = this.projects;
    const dialogRef = this.dialog.open(AddProjectDialog, {
      width: '900px',
      data: this.dialogueProjects
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      //this.animal = result;
    });
  }


  openAddNotesDialog(days): void {
  //let notes;
  this.dialogueNotes = this.weekEntries;
  this.dialogueNotes["days"] = days;
  //notes.weekEntries = this.weekEntries;
    const dialogRef = this.dialog.open(AddNotesDialog, {
      width: '450px', 
      data: this.dialogueNotes
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }



openAddLocationsDialog(selectedValue): void {
this.dialogueLocations["Month"] = selectedValue.substr(3,3);
  //this.dialogueLocations["WeekDates"] = this.dateValues;
  this.dialogueLocations["WeekDates"] = this.weekDays;
  //this.dialogueLocations = this.weekEntries;
    const dialogRef = this.dialog.open(AddLocationsDialog, {
      width: '700px',
      data: this.dialogueLocations
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }

ngOnInit(){
//this.fetchData();
this.isLoading = true;
this.fetchWeekDates();
}


  

fetchData(){
this.apiService.fetch().subscribe((data:  Array<Item>)=>{
//console.log(data);
this.items  =  data;
}, (err)=>{
console.log(err);
});
}

fetchWeekDates(){
    this.apiService.fetchDates().subscribe(data => {
      this.bindWeekEntryData(data);
      this.isLoading = false;
  }, (err)=>{
  console.log(err);
  });
}


bindWeekEntryData(data)
{
  console.log(data["SevenWeeks"]);
  this.jsonData = data;
  this.userData = this.jsonData["User"].FirstName + ' '+ this.jsonData["User"].LastName;
  //this.addNotesData.reasonList = data["ReasonList"];
  //this.addNotesData.locations = data["Locations"];
  // this.addNotesData.approverList = data["ApproverList"];
    this.weekList  =  data["SevenWeeks"];
    this.weekEntries = data["WeeklyEntries"];
    this.projects = data["Projects"];
    this.projects["userDefaults"] = data["UserDefaults"];
    this.dialogueProjects = this.projects;
    this.dialogueLocations = data["Locations"];
    this.dialogueLocations["UserWorkLocationIdArray"] = data["UserWorkLocationIdArray"];
    let count = this.weekEntries.length;
    let projLen = this.projects.length;

          for(let j=0; j< count; j++)
          {
              //To Do
              this.weekEntries[j].reasonList = data["ReasonList"];
              this.weekEntries[j].locations = data["Locations"];
              this.weekEntries[j].approverList = data["ApproverList"];
              //End

                this.dayOneTotalHours += this.weekEntries[j].Day1.Hours*1;
                this.dayTwoTotalHours += this.weekEntries[j].Day2.Hours*1;
                this.dayThreeTotalHours += this.weekEntries[j].Day3.Hours*1;
                this.dayFourTotalHours += this.weekEntries[j].Day4.Hours*1;
                this.dayFiveTotalHours += this.weekEntries[j].Day5.Hours*1;
                this.daySixTotalHours += this.weekEntries[j].Day6.Hours*1;
                this.daySevenTotalHours += this.weekEntries[j].Day7.Hours*1;
                for(let y=0;y<projLen;y++)
                  {
                  if(this.weekEntries[j].ProjId == this.projects[y].Id)
                  this.weekEntries[j].prjs = this.projects[y];
                  }
      
                for(let i=1; i<= 7; i++)
                {
                    let Day = "Day"+i;
                    if(this.weekEntries[j][Day] != null)
                     this.weekHours[i] = this.weekEntries[j][Day];
                    else
                    this.weekHours[j] = "";
                  
                    Day = "";
                }
            }

          for(let i = 0; i < 7; i++)
          {
            if(data["SevenWeeks"][i].IsCurrentWeek == true)
            {
            this.isSelected = true;
            this.selectedValue = data["SevenWeeks"][i].Week;
            this.dateValues = data["SevenWeeks"][i].DateValues;
            }
          }
      this.dayTotalHours = this.dayOneTotalHours +this.dayTwoTotalHours+this.dayThreeTotalHours+this.dayFourTotalHours+this.dayFiveTotalHours+this.daySixTotalHours+this.daySevenTotalHours;
        this.setWeekDays(this.selectedValue);
}


setWeekDays(data)
{
    let Week ="";
    this.weekDays= [ 
    {Date:'1',Day:'SAT'},
    {Date:'2',Day:'SUN'},
    {Date:'3',Day:'MON'},
    {Date:'4',Day:'TUE'},
    {Date:'5',Day:'WED'},
    {Date:'6',Day:'THU'},
    {Date:'7',Day:'FRI'},
    ];
    let datenow = data.substring(0,2);

    let filteredObj = this.weekList.find(function(item, i){
      if(item.Week == data){
        return item;
      }
    });

    for(let w=0; w<7;w++)
    {
      if(this.isSelected)    {
      this.weekDays[w].Date = this.dateValues[w];  }
      else {
        this.weekDays[w].Date = filteredObj.DateValues[w];      }
    }
 
}

weekLevelChangeAction(selectedWeekValue)
{
this.errorText = '';
this.weekEntries = null;
this.isLoading = true;
this.isSelected = false;
  this.setWeekDays(selectedWeekValue);
  this.apiService.fetchWeekRange(selectedWeekValue).subscribe((data:  any)=>{
  this.setTotalHours();
  this.bindWeekEntryData(data);
  this.isLoading = false;
  console.log("WeekChangeData:" + data);
  }, (err)=>{
  console.log(err);
  });
}

setTotalHours()
{
  this.dayOneTotalHours = 0;
  this.dayTwoTotalHours = 0;
  this.dayThreeTotalHours = 0;
  this.dayFourTotalHours = 0;
  this.dayFiveTotalHours = 0;
  this.daySixTotalHours = 0;
  this.daySevenTotalHours = 0;
  this.dayTotalHours = 0;
}

projectLevelChangeAction(selectedProject, j)
{
  let filteredObj = this.projects.find(function(item, i){
  if(item.ProjName == selectedProject.ProjName){
  selectedProject.prjs = item;
    return selectedProject;
  }
});

this.subProjects = filteredObj;
}

Save(days)
{
   this.apiService.genericPost().subscribe(resp =>{
             console.log('Change inserted in audit table');
           },
           (error: any) => console.log(error)
           );

  //this.apiService.postDates(days).subscribe((resp =>{
    //          console.log('Change inserted in audit table');
     //       });
}

filterItemsOfType(type){
    return this.projects.filter(x => x.ProjName == type);
}

total(days)
{
  return days.Day1.Hours*1 + days.Day2.Hours*1+ days.Day3.Hours*1+ days.Day4.Hours*1+ days.Day5.Hours*1+ days.Day6.Hours*1+ days.Day7.Hours*1;
}


changeCheck(event, days)
{
  //this.disableButton = !event.checked;
      if(event.checked)
      {
      this.selectedCheckBoxes.push(event.source.id);
      this.selectedCheckBoxesData.push(days);
      }
      else
      {
      this.removeRowSelection(event.source.id);
      //this.selectedCheckBoxes.pop(event.source.id);
      }

      if(this.selectedCheckBoxes.length*1 > 0)
      this.disableButton = false;
      else
      this.disableButton = true;
}


removeRowSelection(rowIndex:string) {
    const index: number = this.selectedCheckBoxes.indexOf(rowIndex);
    if (index !== -1) {
        this.selectedCheckBoxes.splice(index, 1);
        this.selectedCheckBoxesData.splice(index,1);
    }        
}

deleteSelectedRows()
{
  console.log(this.selectedCheckBoxes);
  let count = this.weekEntries.length;
  let checkedCount = this.selectedCheckBoxes.length;
  const deletedCount: number = 0;
  const lastIndex: number = 0;
const tmpData = this.weekEntries;

this.selectedCheckBoxesData.forEach(p => this.weekEntries.splice(this.weekEntries.indexOf(p), 1));

//this.selectedCheckBoxes.forEach(p => tmpData.splice(tmpData.indexOf(p), 1));

  for(let i = 0; i< checkedCount; i++)
  {
  const indexWeek: number = this.selectedCheckBoxes[i]*1;
     this.checkedBox[indexWeek] = false;
  }

  //this.selectedCheckBoxes.forEach(p => this.weekEntries.splice(this.weekEntries.indexOf(p), 1));
  this.selectedCheckBoxes = [];
  this.selectedCheckBoxesData = [];
}

copySelectedRows()
{
this.copied = false;
}

addNewRow()
{
let tmpWeeksData = this.weekEntries;
const rowCount: number = tmpWeeksData.length;
this.weekEntries[rowCount] = tmpWeeksData[rowCount-1];
this.checkWeekEntryDuplicateRows(this.weekEntries);
}

checkWeekEntryDuplicateRows(weekObj)
{
  this.errorText = '';
  let maxRow = weekObj.length;
    for(let i =0; i< maxRow; i++)
    {
      for(let j = maxRow -1; j > i; j--)
      {
        if(weekObj[i] == weekObj[j])
        {
          this.duplicateRows.push(i+1,j+1);
          this.hoursError = true;
          this.errorText = this.errorText + '  ' + "Duplicate Rows are" + this.duplicateRows;
          this.duplicateRows = [];
        }
      }

    }
}

pasteSelectedRows()
{
if(!this.copied)
{
  let checkedCount = this.selectedCheckBoxes.length;
  for(let i = 0; i< checkedCount; i++)
  {
      const indexWeek: number = this.selectedCheckBoxes[i]*1;
      let newRow = this.weekEntries[indexWeek];
      this.weekEntries.push(newRow);
  }
}

}


restrictNumeric(e)
{
  let input;
  if (e.metaKey || e.ctrlKey) {
    return true;
  }
  if (e.which === 32) {
   return false;
  }
  if (e.which === 0) {
   return true;
  }
  if (e.which < 33) {
    return true;
  }
  input = String.fromCharCode(e.which);
  return !!/[\d\s]/.test(input);
}

restrictHours(hours)
{
if(hours == '')
{
  hours = 0;
  return hours;
}
let showError: boolean = false;
  //this.errorText = '';
  let input: number;
  input = hours*1; 
  if(input > 24)
  {
  this.hoursError = true;
  this.errorText = "Enter hours between 0 and 24";
  }
  else
  {
  let weekEntryCount = this.weekEntries.length;
      for(let i=0;i<weekEntryCount;i++)
      {
            if(this.weekEntries[i].Day1 != 'undefined' || this.weekEntries[i].Day2 != 'undefined'
             || this.weekEntries[i].Day3 != 'undefined' || this.weekEntries[i].Day4 != 'undefined'
             || this.weekEntries[i].Day5 != 'undefined' || this.weekEntries[i].Day6 != 'undefined'
             || this.weekEntries[i].Day7 != 'undefined')
             {
                if(this.weekEntries[i].Day1.Hours > 24 || this.weekEntries[i].Day2.Hours > 24
                || this.weekEntries[i].Day3.Hours > 24 || this.weekEntries[i].Day4.Hours > 24
                || this.weekEntries[i].Day5.Hours > 24 || this.weekEntries[i].Day6.Hours > 24
                 || this.weekEntries[i].Day7.Hours > 24)
                {
                  showError = true;
                }
            }
      }

      if(!showError)
      {
              this.errorText = '';
              this.hoursError = false;
      }
  }
  
}


dateChangeEvent(event)
{
    let tst = this.eventDate.toString();
    let newDate = new Date(tst);

    let startDate = '';
    let startMon = '';
    let startYear = '';

    let endDate = '';
    let endMon = '';
    let endYear = '';

    if(event.value.getDay() != 5 && event.value.getDay() != 6)
    {

      let lastSat = this.getLastSatDay(event.value,6);

       startDate = lastSat.toString().substr(8,2);
       startMon = lastSat.toString().substr(4,3);
       startYear = lastSat.toString().substr(11,4);

      let nxtFri = this.getNextFridayDay(newDate,5);

       endDate = nxtFri.toString().substr(8,2);
       endMon = nxtFri.toString().substr(4,3);
       endYear = nxtFri.toString().substr(11,4);

  
    }

    else
      {
          if(event.value.getDay() == 5)
          {
              let lastSat = this.getLastSatDay(event.value,6);

               startDate = lastSat.toString().substr(8,2);
               startMon = lastSat.toString().substr(4,3);
               startYear = lastSat.toString().substr(11,4);


               endDate = newDate.toString().substr(8,2);
               endMon = newDate.toString().substr(4,3);
               endYear = newDate.toString().substr(11,4);

          }
          else
          {
               startDate = newDate.toString().substr(8,2);
               startMon = newDate.toString().substr(4,3);
               startYear = newDate.toString().substr(11,4);

              let nxtFri = this.getNextFridayDay(newDate,5);

               endDate = nxtFri.toString().substr(8,2);
               endMon = nxtFri.toString().substr(4,3);
               endYear = nxtFri.toString().substr(11,4);

          }

      }

      let apiParam = startDate + '-'+ startMon + '-'+ startYear + ' to '+ endDate + '-'+ endMon + '-'+ endYear;
      this.weekLevelChangeAction(apiParam);
      //console.log(lastSat);
      //console.log(nxtFri);
      console.log(apiParam);
}

getLastSatDay (startDate, dayOfWeek){
let lstSatDay = new Date();
lstSatDay = startDate;
    let dayOffset = dayOfWeek - startDate.getDay() - 7;
    lstSatDay.setDate(startDate.getDate() + dayOffset);
    return lstSatDay;
}


getNextFridayDay (startDate, dayOfWeek){
let nxtFriday = new Date();
nxtFriday = startDate;
    let dayOffset = dayOfWeek > startDate.getDay()
        ? dayOfWeek - startDate.getDay()
        : dayOfWeek - startDate.getDay() + 7;

    //startDate.setDate(startDate.getDate() + dayOffset);
    nxtFriday.setDate(startDate.getDate() + dayOffset);
    return nxtFriday;
}

}


@Component({
  selector: 'addProjects',
  templateUrl: 'addProjects.html',
})
export class AddProjectDialog implements OnInit {
public notes:any[] = [];
//console.log(this.dialogueProjects);
  constructor(public dialogRef: MatDialogRef<AddProjectDialog>,@Inject(MAT_DIALOG_DATA) public data: {notes: data})
    {

    }

  onNoClick(): void {
    this.dialogRef.close();
  }

deleteSelectedDefaultRows(userDefault) : any
{
let tempDefault = this.data["userDefaults"];
console.log(userDefault);
console.log(this.data);
//return this.data.splice(this.data.indexOf(userDefault), 1);
//tempDefault.splice(tempDefault.indexOf(userDefault,1));
tempDefault = tempDefault.filter(t => t != userDefault);
this.data["userDefaults"] = tempDefault;

console.log(this.data["userDefaults"]);
//return this.data;
//this.dialogRef.close();
}
      public ngOnInit():void{
              console.log(this.notes);
              console.log(this.data);
           }
}

//}


@Component({
  selector: 'addNotes',
  templateUrl: 'addNotes.html',
})
export class AddNotesDialog implements OnInit {
public addNotes:any[] = [];
//console.log(this.dialogueProjects);
  constructor(
    public dialogRef: MatDialogRef<AddNotesDialog>,@Inject(MAT_DIALOG_DATA) public data: {addNotes: data}) {}

  onNoClick(): void {
    this.dialogRef.close();
  }

 public ngOnInit():void{
               //this.addNotes = this.data;
          
          console.log(this.addNotes);
          console.log(this.data);
           }

}

@Component({
  selector: 'addLocations',
  templateUrl: 'addLocations.html',
})
export class AddLocationsDialog implements OnInit {
public locationData:any[] = [];
  constructor(
    public dialogRef: MatDialogRef<AddLocationsDialog>,@Inject(MAT_DIALOG_DATA) public data: {locationData: data}) {}

  onNoClick(): void {
    this.dialogRef.close();
  }

 public ngOnInit():void{
               //this.locationData = this.data;
          
          console.log(this.locationData);
          console.log(this.data);
           }

}


//Test to make draggable doalogue boxes

@Directive({
  selector: '[appDraggableDialog]',
})
export class DraggableDialogDirective implements OnInit, OnDestroy {
  // Element to be dragged
  private _target: HTMLElement;

  // dialog container element to resize
  private _container: HTMLElement;

  // Drag handle
  private _handle: HTMLElement;
  private _delta = {x: 0, y: 0};
  private _offset = {x: 0, y: 0};

  private _destroy$ = new Subject<void>();

  private _isResized = false;

  constructor(
    private _elementRef: ElementRef,
    private _zone: NgZone,
    private _cd: ChangeDetectorRef,
  ) {}

  public ngOnInit(): void {
    this._elementRef.nativeElement.style.cursor = 'default';
    this._handle = this._elementRef.nativeElement.parentElement.parentElement.parentElement;
    this._target = this._elementRef.nativeElement.parentElement.parentElement.parentElement;
    this._container = this._elementRef.nativeElement.parentElement.parentElement;
    this._container.style.resize = 'both';
    this._container.style.overflow = 'hidden';

    this._setupEvents();
  }

  public ngOnDestroy(): void {
    if (!!this._destroy$ && !this._destroy$.closed) {
      this._destroy$.next();
      this._destroy$.complete();
    }
  }

  private _setupEvents() {
    this._zone.runOutsideAngular(() => {
      const mousedown$ = fromEvent(this._handle, 'mousedown');
      const mousemove$ = fromEvent(document, 'mousemove');
      const mouseup$ = fromEvent(document, 'mouseup');

      const mousedrag$ = mousedown$.pipe(
        switchMap((event: MouseEvent) => {
          const startX = event.clientX;
          const startY = event.clientY;

          const rectX = this._container.getBoundingClientRect();
          if (
            // if the user is clicking on the bottom-right corner, he will resize the dialog
            startY > rectX.bottom - 15 &&
            startY <= rectX.bottom &&
            startX > rectX.right - 15 &&
            startX <= rectX.right
          ) {
            this._isResized = true;
            return observableOf(null);
          }

          return mousemove$.pipe(
            map((innerEvent: MouseEvent) => {
              innerEvent.preventDefault();
              this._delta = {
                x: innerEvent.clientX - startX,
                y: innerEvent.clientY - startY,
              };
            }),
            takeUntil(mouseup$),
          );
        }),
        takeUntil(this._destroy$),
      );

      mousedrag$.subscribe(() => {
        if (this._delta.x === 0 && this._delta.y === 0) {
          return;
        }

        this._translate();
      });

      mouseup$.pipe(takeUntil(this._destroy$)).subscribe(() => {
        if (this._isResized) {
          this._handle.style.width = 'auto';
        }

        this._offset.x += this._delta.x;
        this._offset.y += this._delta.y;
        this._delta = {x: 0, y: 0};
        this._cd.markForCheck();
      });
    });
  }

  private _translate() {
    // this._target.style.left = `${this._offset.x + this._delta.x}px`;
    // this._target.style.top = `${this._offset.y + this._delta.y}px`;
    // this._target.style.position = 'relative';
    requestAnimationFrame(() => {
      this._target.style.transform = `
        translate(${this._offset.x + this._delta.x}px,
                  ${this._offset.y + this._delta.y}px)
      `;
    });
  }
}



/**  Copyright 2018 Google Inc. All Rights Reserved.
    Use of this source code is governed by an MIT-style license that
    can be found in the LICENSE file at http://angular.io/license */

