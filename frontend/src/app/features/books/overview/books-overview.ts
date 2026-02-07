import {
  Component,
  ElementRef,
  inject,
  signal,
  ViewChild,
} from "@angular/core";
import { CommonModule } from "@angular/common";
import { CreateBook } from "src/app/services/book";
import { BookService } from "src/app/services/BookService";
import { form, FormField, required } from "@angular/forms/signals";
import { Router } from "@angular/router";
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
  private router = inject(Router);
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

  onCancel() {
    this.addBookDialog.nativeElement.close();
  }

  onSubmit(event: Event) {
    event.preventDefault();
    const createBook: CreateBook = this.bookCreateModel();

    this.booksService.createBook(createBook).subscribe({
      next: (createdBook) => {
        console.log("🎉 ID des neuen Buches:", createdBook.bookId);
        this.addBookDialog.nativeElement.close();
        this.router.navigate(["/books", createdBook.bookId]);
      },
    });
  }

  navigateToBook(bookId: number) {
    this.router.navigate(["/books", bookId]);
  }
}
