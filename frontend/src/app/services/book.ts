export interface Book {
  bookId: number;
  title: string;
  author: string; // im Backend NICHT nullable
  genre?: string;
  description?: string;
  pages?: number;
  characters: Character[];
}
export interface CreateBook {
  title: string;
  author?: string;
}

export interface Character {
  characterId: number;
  name: string;
  description?: string;
  profession?: string;
  species?: Species;
}

export interface Species {
  speciesId: number;
  name: string;
  description?: string;
}
