import { Entry } from '../entry/entry.interface';

export interface PhoneBook {
    id: number;
    name: string;
    entries: Entry[]; 
}