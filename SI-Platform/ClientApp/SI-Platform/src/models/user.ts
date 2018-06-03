export interface IUser {
    firstName: string,
    lastName: string,
    city: string,
    phone: string,
    email: string,
    id: string,
    type: string
}

export interface IUsersList {
    users: IUser[]
}