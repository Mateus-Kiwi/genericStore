import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class BusyService {
  busyReuestCount = 0;

  constructor(private spinnerService: NgxSpinnerService) { }

  busy() {
    this.busyReuestCount++;
    this.spinnerService.show(undefined, {
      type: 'cube-transition',
      bdColor: 'rgba(255,255,255,0.7)',
      color: '#413632'
    });
  }

  idle(){
    this.busyReuestCount--;
    if(this.busyReuestCount <= 0){
      this.busyReuestCount = 0;
      this.spinnerService.hide();
    }
  }
}
