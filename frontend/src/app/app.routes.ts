import { Routes } from "@angular/router";
import { BooksOverview } from "./features/books/overview/books-overview";
import { BookDetails } from "./features/books/book-details/book-details";
import { Home } from "./features/home/home";

export const routes: Routes = [
  { path: "", redirectTo: "/books", pathMatch: "full" },
  { path: "books", component: BooksOverview },
  { path: "books/:id", component: BookDetails },
];
