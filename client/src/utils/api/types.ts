export interface IProcessResult{
  errors: string[]
  warnings: string[]
  messages: string[]
  status: ProcessStatus
}

export interface IProcessResultWithData<TData> extends IProcessResult {
  data: TData[]
}




export const ProcessStatus = {
  Success: "Success",
  Warning: "Warning",
  Error: "Error",
  Unknown: "Unknown"
}
export type ProcessStatus = typeof ProcessStatus[keyof typeof ProcessStatus];