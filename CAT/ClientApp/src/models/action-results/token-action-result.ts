import { ActionResult } from "./base/action-result";

export class TokenActionResult extends ActionResult {
  accessToken: string;
  userName: string;
  avatarUrl: string;
  role: string;
}
