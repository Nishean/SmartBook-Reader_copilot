export interface Book {
    title: string;
    author: string;
    isbn: string;
    publicationDate: Date;
    chapters: Chapter[];
}

export interface Chapter {
    title: string;
    startTime: number; // in seconds
    endTime: number;   // in seconds
}

export interface AudioSettings {
    volume: number; // range from 0 to 100
    speed: number;  // speed multiplier, e.g., 1.0 for normal speed
    format: 'mp3' | 'wav';
}

export interface UserPreferences {
    preferredVoice: string;
    darkMode: boolean;
    lastOpenedBook: string;
}