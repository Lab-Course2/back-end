﻿using MindMuse.Data.Contracts.Models;
using MindMuse.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Data.Repositories
{
    public class BookAppointmentRepository : Repository<BookAppointment>
    {
        public BookAppointmentRepository(MindMuseContext context) : base(context)
        {
        }
    }
}