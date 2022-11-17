import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { IRegister } from 'src/app/model/iregister';
import { ITeachers } from 'src/app/model/iteachers';
import { MasterService } from 'src/app/service/master.service';

@Component({
  selector: 'app-registered-list',
  templateUrl: './registered-list.component.html',
  styleUrls: ['./registered-list.component.css']
})
export class RegisteredListComponent implements OnInit {

  formRegister!:FormGroup;
  formData!:IRegister;
  teacherList:ITeachers[]=[];
  studentList:any[]=[];
  studentID!:number;
  
  constructor(private master:MasterService) { }

  ngOnInit(): void {
    this.loadForm();
    this.teacher();
    this.getData();
  }
  loadForm()
  {
    this.formRegister=new FormGroup({
      firstName:new FormControl(""),
      lastName:new FormControl(""),
      dob:new FormControl(""),
      gender:new FormControl(""),
      selectTeacher:new FormControl("0")
     
    })
  }
  teacher()
  {
    this.master.getTeacher().subscribe(ops=>
      this.teacherList=ops)
      console.log("get teachers"+this.teacherList);
  }

  getData(){
    this.master.getStudents().subscribe(res=>{
      this.studentList=res
      console.log("My result",res);
      console.log("My result",this.studentList);
    })
  }
  editMember(id:number){
    this.master.getStudentById(id).subscribe(res=>{
      this.setFormData(res);
     
    })
  }
  setFormData(data:IRegister)
  {
    if(data.id !==undefined && data.id !==null)
    {
      this.studentID = data.id
    }
    this.formRegister.get('firstName')?.setValue(data.firstName);
    this.formRegister.get('lastName')?.setValue(data.lastName);
    this.formRegister.get('dob')?.setValue(data.dob);
    this.formRegister.get('gender')?.setValue(data.gender);
    this.formRegister.get('selectTeacher')?.setValue(data.teacherId);

  }
  deleteMember(id:number)
  {
    this.master.deleteData(id).subscribe(rest=>{
      this.getData();
      window.location.reload();
    })
  }
  onSave()
  {
    this.formData={
      firstName:this.formRegister.controls['firstName'].value,
      lastName:this.formRegister.controls['lastName'].value,
      dob:this.formRegister.controls['dob'].value,
      gender:this.formRegister.controls['gender'].value,
      teacherId:this.formRegister.controls['selectTeacher'].value,
    }

    if(this.studentID !==undefined && this.studentID !==null)
    {
      if(this.formRegister.valid)
      {
        this.formData.id = this.studentID;
        this.master.updateData(this.formData).subscribe(res=>{
          alert(res)
          window.location.reload();
        })
      }
    }
    else{
      if(this.formRegister.valid)
      {
        console.log(this.formData)
        this.master.postDate(this.formData).subscribe(res=>{
          alert(res)
          window.location.reload();
        })
      }
    }

  }
  get f(){
    return this.formRegister.controls;
  }


}
