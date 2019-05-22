export class RegisterAccount {
  constructor(
    public email: string,
    public userName: string,
    public password: string,
    public confirmedPassword: string,
    public firstName: string,
    public secondName: string,
    public file: any
  ) {
  }
}
