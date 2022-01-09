import { AreaRating } from "./AreaRating";
import { KnowledgeArea } from "./KnowledgeArea";
import {User} from "./User";

export class Knowledge {
    id: number;
    title: string;
    description: string;
    userId: string;
    AreaRating: AreaRating[];
  }