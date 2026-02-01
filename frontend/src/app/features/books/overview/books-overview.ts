import {
  Component,
  ElementRef,
  inject,
  signal,
  ViewChild,
} from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { CreateBook } from "src/app/services/book";
import { BookService } from "src/app/services/BookService";
import { form, FormField, required } from "@angular/forms/signals";
interface CreateBookFormdata {
  title: string;
  author: string;
}

@Component({
  selector: "app-books-overview",
  imports: [CommonModule, FormField],
  templateUrl: "./books-overview.html",
  styleUrl: "./books-overview.scss",
})
export class BooksOverview {
  private booksService = inject(BookService);
  books = this.booksService.books;

  bookCreateModel = signal<CreateBookFormdata>({
    title: "",
    author: "",
  });

  createBookForm = form(this.bookCreateModel, (schemaPath) => {
    required(schemaPath.title);
    required(schemaPath.author);
  });

  @ViewChild("addBookDialog")
  addBookDialog!: ElementRef<HTMLDialogElement>;

  openAddBookDialog() {
    this.addBookDialog.nativeElement.showModal();
  }

  onSubmit(event: Event) {
    event.preventDefault();
    const createBook: CreateBook = this.bookCreateModel();
    this.booksService.createBook(createBook).subscribe(() => {
      this.addBookDialog.nativeElement.close();
    });
  }
}
