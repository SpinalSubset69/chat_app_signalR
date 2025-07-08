import { NgModule } from '@angular/core';
import { NavbarComponent, PaginationComponent } from './components';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [NavbarComponent, PaginationComponent],
  imports: [CommonModule],
  exports: [NavbarComponent, PaginationComponent],
})
export class SharedModule {}
