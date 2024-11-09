import {NewOptionModel} from './new-option.model';

export interface NewPollModel {
  name: string;
  options: NewOptionModel[]
}
