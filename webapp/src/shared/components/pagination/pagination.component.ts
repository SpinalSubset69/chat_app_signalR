import {
  Component,
  EventEmitter,
  Input,
  OnChanges,
  OnInit,
  Output,
  SimpleChanges,
} from '@angular/core';
import { Pagination } from './models/pagination';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
})
export class PaginationComponent implements OnChanges, OnInit {
  @Output() onPageChanged!: EventEmitter<number>;
  @Input() actualPage!: number;
  @Input() totalPages!: number;

  paginationButtons: Array<Pagination> = [];

  constructor() {
    this.onPageChanged = new EventEmitter<number>();
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['acutalPage']) this.buildPaginationButtons();
  }

  ngOnInit(): void {
    this.buildPaginationButtons();
  }

  private buildPaginationButtons() {
    this.paginationButtons = [];
    const minPage = this.actualPage - 1;
    const maxPage = this.actualPage + 1;

    for (let i = minPage === 0 ? 1 : minPage; i <= maxPage; i++) {
      if (i > this.totalPages) continue;
      this.paginationButtons.push({
        isAcutalPage: this.actualPage === i,
        index: i,
        pageNumber: i,
      });
    }
  }

  pageChanged(page: number) {
    this.actualPage = page;
    this.buildPaginationButtons();
    this.onPageChanged.emit(this.actualPage);
  }
}
