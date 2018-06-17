export interface IIdea {
  id: string,
  title: string,
  description: string,
  startFundingDate: Date,
  stopFundingDate: Date,
  status: string,
  authorId: string,
  target: number,
  fullfillment: number
}

export interface IIdeasList {
  ideas: IIdea[]
}
