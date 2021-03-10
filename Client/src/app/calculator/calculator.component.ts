import { Component, OnInit } from '@angular/core';
import { CalculatorService } from 'src/app/calculator/calculator.service';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.scss']
})
export class CalculatorComponent implements OnInit {
  public output: string;
  constructor(private service: CalculatorService) { }
  ngOnInit() { }
  public onCalculate(scheme: string) {
    this.service
      .calculate(scheme)
      .subscribe({
        next: result => this.output = result,
        error: error => console.log(error),
      })
  }
  public addValue(char: any) {
    this.output = this.output ? this.output += char : char;
  }
}
