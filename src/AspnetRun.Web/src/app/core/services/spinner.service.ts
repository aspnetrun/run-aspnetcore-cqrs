import { Injectable } from '@angular/core';
import { NgxUiLoaderConfig, NgxUiLoaderService } from 'ngx-ui-loader';

@Injectable()
export class SpinnerService {
    config: NgxUiLoaderConfig;

    constructor(private ngxUiLoaderService: NgxUiLoaderService) {
        this.config = this.ngxUiLoaderService.getDefaultConfig();
        this.config.fgsSize = 40; // 60
        this.config.fgsType = "rectangle-bounce-pulse-out"; // "ball-spin-clockwise"
        this.config.bgsOpacity = 1; // 0.5
        //this.config.bgsPosition = "center-center"; // "bottom-right"
        this.config.bgsSize = 40; // 60
        this.config.bgsType = "rectangle-bounce-pulse-out"; // "ball-spin-clockwise"
        this.config.blur = 1; // 5
    }
}
