﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelpToRent.Data;
using HelpToRent.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using System.Xml;
using System.ComponentModel;
using System.IO;
using System.Xml.Linq;
using HtmlAgilityPack;

namespace HelpToRent.Controllers
{
    public class HousesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HousesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Houses
        public async Task<IActionResult> Index()
        {
            return View(await _context.House.ToListAsync());
        }

        // GET: Houses/Search
        public async Task<IActionResult> SearchForm()
        {
            return View();//No need the name because is already in the name
        }

        // POST: Houses/SearchForm
        public async Task<IActionResult> ShowSearchValues(Direction direction)
        {
            //The view we are looking for (Index)
            //And the data that come whith it, whith the proper filter

            return View("Index", await _context.House.Where(h =>h.Directions.Town.Contains(direction.Town)).ToListAsync());
        }
       
        // GET: Houses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var house = await _context.House
                .FirstOrDefaultAsync(m => m.Id == id);
            if (house == null)
            {
                return NotFound();
            }

            return View(house);
        }

        public void ScrapingWeb(String Url)
        {
           // WebClient webClient = new WebClient();

            //Event handlers to show progress and to detect that the file is downloaded
            // webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            //  webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);

            //first parameter is the url of the file you want to download and the second
            //parameter is path to local disk to which you want to save the file.
            //To download file without blocking the main thread we use asynchronous method DownloadFileA­sync.
            //webClient.DownloadFileAsync(new Uri(Url), @"XMLFiles/MyXml.txt");
          //  String xml = "XMLFiles/xml.txt";

           // webClient.DownloadFile(Url, @xml);

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("https://en.wikipedia.org/wiki/Greece");

            //var metascore = doc.DocumentNode.SelectNodes("count(//[@id = 'container'] / div[11] / div / h1)");
            var navigator = doc.CreateNavigator();
            var expr = navigator.Compile("//span[@class='toctext']");
            var count = navigator.Evaluate(expr);

            Console.Write("==========================================>>>>>" + count);

            /* for (int i = 0; i <= metascore.Count; i++)
             {
                 Console.Write("==========================================>>>>>"+metascore[i].InnerText);

             }*/
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
           // progressBar.Value = e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
          //  MessageBox.Show("Download completed!");
        }

        // GET: Houses/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Houses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Direction,Price,Bills,Deposit,ContractPeriod,ContactName")] House house)
        {
            if (ModelState.IsValid)
            {
                _context.Add(house);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(house);
        }

        // GET: Houses/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var house = await _context.House.FindAsync(id);
            if (house == null)
            {
                return NotFound();
            }
            return View(house);
        }

        // POST: Houses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Direction,Price,Bills,Deposit,ContractPeriod,ContactName")] House house)
        {
            if (id != house.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(house);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HouseExists(house.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(house);
        }

        // GET: Houses/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var house = await _context.House
                .FirstOrDefaultAsync(m => m.Id == id);
            if (house == null)
            {
                return NotFound();
            }

            return View(house);
        }

        // POST: Houses/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var house = await _context.House.FindAsync(id);
            _context.House.Remove(house);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HouseExists(int id)
        {
            return _context.House.Any(e => e.Id == id);
        }
    }
}
