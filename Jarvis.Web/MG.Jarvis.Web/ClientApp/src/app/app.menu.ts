// ToDo :  This is just a temporary data for menus - We need to get from DB
import { IMenuItem } from './framework/fw/services/menu.service';

export let initialMenuItems: Array<IMenuItem> = [
    {
      text: 'Dashboard',
      icon: 'fa fa-tachometer',
      route: 'dashboard',
      submenu: null
    },
    {
      text: 'Contract Management',
      icon: 'fa fa-pencil',
      route: null,
      submenu: [
        {
            text: 'Dashboard',
            icon: '',
            route: 'hoteladmindashboard',
            submenu: null
        },
        {
          text: 'Contract',
          icon: '',
          route: 'createroomtype',
          submenu: null
      },
      {
        text: 'Clause Library',
        icon: '',
        route: 'createroomtype',
        submenu: null
      },
      {
        text: 'Templates',
        icon: '',
        route: 'createroomtype',
        submenu: null
      }
    ]
    },
    {
      text: 'Hotel Management',
      icon: 'fa fa-user',
      route: null,
      submenu: [
        {
          text: 'Dashboard',
          icon: '',
          route: '',
          submenu: null
      },
        {
            text: 'Hotel Profile',
            icon: '',
            route: '/hotelmgmt/hotels',
            submenu: null
        },
        {
          text: 'Reservation',
          icon: '',
          route: 'agentdashboard',
          submenu: null
      }
    ]
    },
    {
      text: 'Master Data',
      icon: 'fa fa-database',
      route: null,
      submenu: null
    },
    {
      text: 'Reports',
      icon: 'fa fa-file-text-o',
      route: null,
      submenu: null
    }
  ];
