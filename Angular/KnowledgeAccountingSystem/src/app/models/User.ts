import { Knowledge } from "./Knowledge";
import { Role } from "./Role";

export class User{
    id: string;
    email: string;
    firstName: string;
    lastName: string;
    knowledge: Knowledge[];
    role: Role[];
}