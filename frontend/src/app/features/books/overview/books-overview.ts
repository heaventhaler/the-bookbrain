import {
  Component,
  effect,
  ElementRef,
  inject,
  OnInit,
  ViewChild,
} from "@angular/core";
import { CommonModule } from "@angular/common";
import { Observable } from "rxjs";
import { FormsModule } from "@angular/forms";
import { Book, CreateBook } from "src/app/services/book";
import { BookService } from "src/app/services/BookService";

@Component({
  selector: "app-books-overview",
  imports: [CommonModule, FormsModule],
  templateUrl: "./books-overview.html",
  styleUrl: "./books-overview.scss",
})
export class BooksOverview {
  books$!: Observable<Book[]>;
  private booksService = inject(BookService);

  @ViewChild("addBookDialog")
  addBookDialog!: ElementRef<HTMLDialogElement>;

  openAddBookDialog() {
    this.addBookDialog.nativeElement.showModal();
  }

  closeAddBookDialog() {
    this.addBookDialog.nativeElement.close();
  }

  onSaveBook(createBook: CreateBook) {
    this.booksService.createBook(createBook).subscribe(() => {
      this.closeAddBookDialog();
    });
  }

  constructor() {
    effect(() => {
      this.books$ = this.booksService.getAll();
    });
  }
}
