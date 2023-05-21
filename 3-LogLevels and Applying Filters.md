
# Using Log Levels and applying filters

## Intro
![](images/7.png)

## Intention of application Loging

> What to Do and what Don't

![](images/8.png)

## Log Levels Defined  

1. Trace (Not Prod) 
> Used in low level diagnostic if we are really having troubles resolving complex issues. Some of this msges might contain sensitive data

2. Debug (Might be temporary in Prod)
> Volume of data is very high as well, use it counscious. 

3. Information
> Using for general flow of the app. Have in some key places can be helpfull 

4. Warning
> Used for abnormal or unexpected events. Generally things triggering this events don't cause a clear fauilure in the app.

5. Error
> Something that cause a failure in the app, the failure can be specific to th user/situation.

6. Critical
> Critical entry should be created under errors that are not specifics to users or situations:
- been out of disk space
- db being completely unavailable 
- Something reflects the complete app is down

![](images/9.png)


## Demo: Using Log Levels

![](images/10.png)

![](images/11.png)

## Categories Defined

> Log Category

![](images/12.png)

![](images/13.png)

![](images/14.png)

## Log Filters

![](images/15.png)

> Applying filters
![](images/16.png)

App Settings
![](images/17.png)

Env Variables
![](images/18.png)

![](images/19.png)

### Demo- Filtering based on Providers

![](images/20.png)

![](images/21.png)

setting the debug provider pathh
![](images/22.png)

ie:
![](images/23.png)

### Applying filters in code

![](images/24.png)

## Summary

![](images/25.png)

