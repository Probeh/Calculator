import { CalculatorComponent } from 'src/app/calculator/calculator.component'
import { CommonModule } from '@angular/common'
import { HttpClientModule } from '@angular/common/http'
import { NgModule } from '@angular/core'
import { FormsModule } from '@angular/forms'

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule
  ],
  declarations: [CalculatorComponent],
  exports: [CalculatorComponent]
})
export class CalculatorModule { }
