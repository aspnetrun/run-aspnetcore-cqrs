import { Component, OnInit } from '@angular/core';
import { NgWizardStepDef, STEP_STATE, NgWizardConfig, THEME, StepChangedArgs, NgWizardService } from 'ng-wizard';

@Component({
  templateUrl: 'dashboard.component.html'
})
export class DashboardComponent implements OnInit {
  steps: NgWizardStepDef[] = [
    {
      title: 'Step 1',
      description: 'Step 1 description',
      content: 'Step 1 Content',
    },
    {
      title: 'Step 2',
      description: 'Step 2 description',
      content: 'Step 2 Content',
      state: STEP_STATE.error,
    },
    {
      title: 'Step 3',
      description: 'Step 3 description',
      content: 'Step 3 Content',
      state: STEP_STATE.disabled,
    },
    {
      title: 'Step 4',
      description: 'Step 4 description',
      content: 'Step 4 Content',
      state: STEP_STATE.hidden,
    },
    {
      title: 'Step 5',
      description: 'Step 5 description',
      content: 'Step 5 Content',
    },
  ];

  config: NgWizardConfig = {
    selected: 0,
    theme: THEME.arrows,
    toolbarSettings: {
      toolbarExtraButtons: [
        { text: 'Finish', class: 'btn btn-info', event: () => { alert("Finished!!!"); } },
        { text: 'Reset', class: 'btn btn-danger', event: () => { this.resetWizard(); } }]
    }
  };

  stepChangedArgs: StepChangedArgs;
  selectedtheme: THEME;
  themes = [THEME.default, THEME.arrows, THEME.circles, THEME.dots];

  constructor(private ngWizardService: NgWizardService) {
  }

  ngOnInit() {
    this.selectedtheme = this.config.theme;
  }

  showPreviousStep(event?: Event) {
    this.ngWizardService.previous();
  }

  showNextStep(event?: Event) {
    this.ngWizardService.next();
  }

  resetWizard(event?: Event) {
    this.selectedtheme = this.config.theme;
    this.ngWizardService.reset();
  }

  themeSelected() {
    this.ngWizardService.theme(this.selectedtheme);
  }

  stepChanged(args: StepChangedArgs) {
    console.log(args.step);
    this.stepChangedArgs = args;
  }
}
