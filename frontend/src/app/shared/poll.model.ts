import {OptionsModel} from './options.model';

export interface PollModel {
  id: string;
  name: string;
  options: OptionsModel[]
}
