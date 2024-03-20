window.onload=function(){

    
  }
var divGetAll =document.getElementsByClassName("GetAll")[0];
var btnGetAll =document.getElementsByClassName("btnGetAll")[0];

btnGetAll.addEventListener("click",function()
{
 GetAllCourses();
});

async function GetAllCourses()
{
   try{
    var respons =await fetch("http://localhost:40307/api/Course");
    var CourseData =await respons.json();

    
    CourseData.forEach(element => {

         var newDivCourse = document.createElement("div");
         newDivCourse.textContent=element.course;
         newDivCourse.style.color="red";
         divGetAll.appendChild(newDivCourse);
        
         element.studentDtos.forEach(e=>{

         var newDivStd= document.createElement("div");
         newDivStd.textContent=e.name;
         divGetAll.appendChild(newDivStd);
          
         })

    });
    var hr = document.createElement("hr");
    hr.style.color="black"
    divGetAll.appendChild(hr);

}
catch(e)
{
    console.log(e);
}

}

//------------------------------------------------GetById


var divGetById=document.getElementsByClassName("GetById")[0];
var btnById =document.getElementsByClassName("btnId")[0];
var id =document.getElementsByClassName("txtId")[0];
var span =document.getElementById("errormeg");

btnById.addEventListener("click",function()
{
    var courseId = Number(id.value.trim());

    if (id.value.trim() === "" || isNaN(courseId) || !Number.isInteger(courseId)) {
        id.value = "";
        span.style.color = "red";
        span.style.display = "inline";
        console.log("Invalid input value. Please enter a valid course ID.");
        return;
    }
    else
    {
        span.style.display = "none";
        GetCourseById(courseId);
 }

})

async function GetCourseById(id) {
    if (isFinite(id)) {
        try {

            var response = await fetch(`http://localhost:40307/api/Course/${id}`);
            if (!response.ok) {
                throw new Error(`Failed to fetch course data: ${response.statusText}`);
            }
            var data = await response.json();

            data.forEach(e=>
                {
                 var nameCourse = document.createElement("h4");
                 nameCourse.textContent = e.course;
                 nameCourse.style.color="red";
                 divGetById.appendChild(nameCourse);

                e.studentDtos.forEach(student => {
                var nameStd = document.createElement("div");
                nameStd.textContent = student.name;
                divGetById.appendChild(nameStd);
            });

                })

            

         
        } catch (error) {
            console.error("An error occurred:", error);
        }
    } else {
        console.log("Invalid id");
    }
}
//------------------------------------------------Delete

var divDeleteById=document.getElementsByClassName("DeleteById")[0];
var btnDById =document.getElementsByClassName("btndelete")[0];
var idDelete =document.getElementsByClassName("txtDeleteId")[0];
var Dspan =document.getElementById("errordeletemeg");


btnDById.addEventListener("click",function()
{
    var courseDId = Number(idDelete.value.trim());

    if (idDelete.value.trim() ==="" || isNaN(courseDId) || !Number.isInteger(courseDId)) {
        courseDId.value = "";
        idDelete.value="";
        Dspan.style.color = "red";
        Dspan.style.display = "inline";
        console.log("Invalid input value. Please enter a valid course ID.");
        return;
    }
    else
    {
        Dspan.style.display = "none";
        DeleteById(courseDId);

 }

})

async function DeleteById(id)
{
    Dspan.style.display = "none";
    if(isFinite(id))
    {
        try{
            var respons =await fetch(`http://localhost:40307/api/Course/${id}`,{method:`DELETE`});
            if (!respons.ok) {
               throw new Error(`Failed to delete course: ${respons.statusText}`);
           }else
           {
            Dspan.style.color = "green";
            Dspan.style.display = "inline";
            Dspan.textContent=`Course of Id: ${id} Deleted`;

           }
            
        }
        catch(e) {
            console.error("An error occurred:", e);
        }
    } else {
        console.log("Invalid id");
    }
 }
 //----------------------------------------------------------------------insert-----------------

//  var btnInsert =document.getElementById("btnInsert");
 
//  btnInsert.addEventListener("click",function()
//  {

//     btnInsert.style.color = "red"; 
//     alert("dsdasa");
//  });

