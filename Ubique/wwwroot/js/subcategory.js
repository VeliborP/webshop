var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/subcategory/getall' },
        "columns": [
            { "data": "name", "width": "15%" },
            { "data": "category.name", "width": "20%" },
            {
                data: { id: "id", lockoutEnd: "lockoutEnd" },
                "render": function (data) {
                    return `
                    <div class="text-center">
                            <a href="/Admin/SubCategory/Edit?id=${data.id}" class="btn btn-success text-white" style="cursor:pointer; width:150px;">
                                <i class="bi bi-pencil-square"></i> Edit
                            </a>
                            <a onclick=Delete('/Admin/SubCategory/Delete?id=${data.id}') class="btn btn-danger text-white" style="cursor:pointer; width:110px;">
                                <i class="bi bi-lock-fill"></i> Remove
                            </a> 
                    </div>
                    `
                },
                "width": "25%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "Once confirmed the changes will be permanent!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, remove it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    })
}