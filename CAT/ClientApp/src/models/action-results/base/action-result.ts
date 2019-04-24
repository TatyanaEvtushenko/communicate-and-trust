import { ActionError } from "./action-error";

export class ActionResult {
    succeeded: boolean;
    errors: ActionError[];
}
