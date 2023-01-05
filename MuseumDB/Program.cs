using Microsoft.EntityFrameworkCore;
using MuseumData;

var optionsBuilder = new DbContextOptionsBuilder<MuseumDBContext>();
var options = optionsBuilder.Options;
using (MuseumDBContext context = new MuseumDBContext(options))
{
    
}
