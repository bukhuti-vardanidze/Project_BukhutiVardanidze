﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.DB;
using Project.DB.Entities;
using Project.DTOs;

namespace Project.Repositories
{
    public interface IStudentRegistrationRepository
    {
        Task<Student> RegisterStudent(StudentDto student);
        Task<Student> GetStudentById(int id);
        Task<List<Student>> GetStudents();
        Task<Student> UpdateStudent(UpdateStudentDto updateStudent);
        Task<Student> DeleteStudentById(int id);

    }

    public class StudentRegistrationRepository : IStudentRegistrationRepository
    {
        private readonly DataContext _context;

        public StudentRegistrationRepository(DataContext context) 
        {
            _context = context;
        }

        public async Task<Student> RegisterStudent(StudentDto student)
        {
            try
            {
                var existingStudent = await _context.Students.FirstOrDefaultAsync(x => x.PersonNumber == student.PersonNumber);

                if (existingStudent != null)
                    throw new InvalidOperationException("Student with the same personal number already exists.");
                
                var newStudent = new Student
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    PersonNumber = student.PersonNumber,
                    Age = student.Age,
                    BirthDate = student.BirthDate,
                    PhoneNumber = student.PhoneNumber,
                    Gender = student.Gender,
                    Email = student.Email,
                    University = student.University,
                    Faculty = student.Faculty,
                    Course = student.Course
                };

                _context.Students.Add(newStudent);
                await _context.SaveChangesAsync();

                return newStudent;
            }
            catch (Exception ex)
            {
                throw; 
            }
        }
        public async Task<Student> GetStudentById(int id)
        {
            try
            {
                var student = await _context.Students.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (student == null)
                    throw new KeyNotFoundException($"Student with ID {id} not found.");
               
                return student;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Student>> GetStudents()
        {
            try
            {
                var student = await _context.Students.ToListAsync();

                return student;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Student> UpdateStudent(UpdateStudentDto updateStudent)
        {
            try
            {
                var student = await _context.Students.FindAsync(updateStudent.Id);

                if (student == null)
                {
                    throw new KeyNotFoundException($"Student with ID {updateStudent.Id} not found.");
                }

                if (updateStudent.PhoneNumber != null)
                {
                    student.PhoneNumber = updateStudent.PhoneNumber;
                }

                if (updateStudent.Email != null)
                {
                    student.Email = updateStudent.Email;
                }

                if (updateStudent.Faculty != null)
                {
                    student.Faculty = updateStudent.Faculty;
                }

                student.Course = updateStudent.Course;


                await _context.SaveChangesAsync();

                return student;
            }
            catch (Exception ex)
            {
                throw; 
            }
        }

        public async Task<Student> DeleteStudentById(int id)
        {
            var findStudent = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (findStudent == null)
            {                
                throw new KeyNotFoundException($"Student with ID {id} not found.");
            }

            _context.Students.Remove(findStudent);
            await _context.SaveChangesAsync();

            return findStudent;
        }



    }
}
