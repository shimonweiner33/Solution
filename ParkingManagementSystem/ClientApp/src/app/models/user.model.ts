export class User {
    member: ExtendMember;
    error: string;
    isUserAuth: boolean;
}
export class Member{
    firstName: string;
    lastName: string;
    username: string;
}
export class Register{
    userName: string;
    password: string;
    verificationPassword: string;
    firstName: string;
    lastName: string;
    phoneArea: string;
    phoneNumber: string;
}
export interface ExtendMember 
{
    firstName: string;
    lastName: string;
    userName: string;
    phoneArea: string;
    phoneNumber: string;
}
export interface ConnectedUsers{
    members: ExtendMember[];
}
