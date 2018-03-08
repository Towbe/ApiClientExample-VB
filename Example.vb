Imports TowbeApi.Api
Imports TowbeApi.Model
Imports TowbeApi.Client

Module Example
    Dim _api As JobsApi
    
    Sub Main()
        Configuration.SetApiKey("")
        Configuration.SetTest()
        
        _api = New JobsApi()
        
        CreateJob()
        GetJob()
        UpdateJob()
    End Sub

    Function CreateJob() As JobKey
        Dim job As JobBody
        job = New JobBody()
        
        Dim c As Client
        c = New Client()
        c.Name = "John Doe"
        c.PhoneNumber = "+96170039873"
        c.PlateNumber = "B-12345"
        c.PolicyNumber = "M/3245465/gfbfdfsd"
        
        job.Client = c
        
        Dim destinations As List(Of Destination)
        destinations = New List(Of Destination)
        
        destinations.Add(New Destination())
        destinations.Item(0).Address = ""
        destinations.Item(0).Latitude = 33.8892241097645
        destinations.Item(0).Longitude = 35.51268898054671
        
        destinations.Add(New Destination())
        destinations.Item(1).Address = ""
        destinations.Item(1).Latitude = 33.8892241097645
        destinations.Item(1).Longitude = 35.51268898054671
        
        job.Destinations = destinations
        
        Dim key As JobKey
        key = _api.DispatchJob(job)
        Console.WriteLine(key.ToString())
        Return key
    End Function
    
    Sub GetJob()
        Dim key As JobKey
        key = CreateJob()
        Dim job As Job
        job = _api.GetJob(key.Id)
        Console.WriteLine(job.ToString())
    End Sub
    
    Sub UpdateJob()
        Dim key As JobKey
        key = CreateJob()
        Dim job As Job
        job = _api.GetJob(key.Id)
        job.Client.Name = "John Snow"
        _api.UpdateJob(job)
        Dim newJob As Job
        newJob = _api.GetJob(key.Id)
        Console.WriteLine(newJob.ToString())
    End Sub
    
End Module
